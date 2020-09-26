import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import NavigationBar from './components/NavigationBar/NavigationBar';
import SearchBar from './components/SearchBar/SearchBar';
import ReportButton from './components/ReportButton/ReportButton';


document.title = "Neighborhood Report";
class App extends Component {
  render () { 
    return (
      <div>
        <NavigationBar/>
        <ReportButton/>
        <SearchBar/>
      </div>
    );
  }
}

export default App;
