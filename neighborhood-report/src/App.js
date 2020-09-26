import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';
import Navbar from 'react-bootstrap/Navbar';
// import Nav from 'react-bootstrap/Nav';
// import NavDropdown from 'react-bootstrap/NavDropdown';
// import FormControl from 'react-bootstrap/FormControl';
// import Form from 'react-bootstrap/Form';
// import Button from 'react-bootstrap/Button';

document.title = "Neighborhood Report";
class App extends Component {
  render(){  
    return (
      <Navbar bg="light">
        <Navbar.Brand href="#home">Brand link</Navbar.Brand>
      </Navbar>

    );
  }
}

export default App;
