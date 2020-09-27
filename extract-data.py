import numpy as np
import pandas as pd 
import difflib
import sys
import folium
from folium import plugins

def main():
	counties_lat_lon = pd.read_csv('../COVID-19_Cases.csv')
	counties_lat_lon = counties_lat_lon.filter(["Lat", "Long_", "Province_State","Admin2"], axis=1)
	counties_lat_lon.columns = ['latitude', 'longitude', 'state', 'county']
	counties_lat_lon = counties_lat_lon[counties_lat_lon['state'] == 'Florida']

	states_cases = pd.read_csv('./live/us-counties.csv')
	fl = states_cases.filter(['date','county','state', 'cases', 'deaths'], axis=1)
	fl = fl[fl['state'] == 'Florida']
	fl = fl.groupby('county').aggregate('sum').reset_index()
	fl = fl.sort_values(by='cases')

	merged_data = counties_lat_lon.merge(fl, on="county")
	middle_lat = merged_data['latitude'].median()
	middle_lon = merged_data['longitude'].median()
	m = folium.Map(location=[middle_lat, middle_lon],titles = "Covid-19-Cases",zoom_start=5)

	points = merged_data[['latitude', 'longitude']].dropna().values
	pointArrays = np.split(points, len(points))

	cases = (merged_data['cases'] / 1000).to_list()

	for point, case in zip(pointArrays, cases):
	    plugins.HeatMap(point, radius=case).add_to(m)
	m.save(outfile='map.html')

if __name__ == '__main__':
    main()
