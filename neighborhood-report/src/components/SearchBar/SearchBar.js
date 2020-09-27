import React from 'react';


class SearchBar extends React.Component {
	render(){
		return(
			<article className="br3 b--black-5 mv7 mw7 shadow-5 center">
				<div className='center'>
					<div className='form center pa4 br3 shadow-3'>
						<input className='f4 pa2 w-70 center' type='text' placeholder='Enter a U.S. County (e.g. Orange County)'/>
						<button className='dim w-30 f4 link pv2 dib white bg-white'>
							<a href='/map.html' target='_blank'>Search</a>
						</button>
					</div>
				</div>
			</article>
	)}
}

export default SearchBar;
