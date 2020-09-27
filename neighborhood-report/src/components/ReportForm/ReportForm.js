import React from 'react';

class ReportForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {state: '', county: ''};

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({value: event.target.value});
    }

    handleSubmit(event) {
        event.preventDefault();
        const requestOptions = {
            method: 'POST'
            // headers: { 'Content-Type': 'application/json' },
            // body: JSON.stringify({ title: 'React POST Request Example' })
        };
        fetch('https://jsonplaceholder.typicode.com/posts', requestOptions)
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <div>
                    Report a new COVID-19 case. Thank you for keeping your neighbors and community informed!
                </div>
                <label>
                    State:
                    <input type="text" placeholder="e.g. Florida" value={this.state.latitude} onChange={this.handleChange} />
                </label>
                <label>
                    County:
                    <input type="text" placeholder="e.g. Orange County" value={this.state.longitude} onChange={this.handleChange} />
                </label>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default ReportForm;
