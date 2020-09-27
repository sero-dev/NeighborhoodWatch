import React, {useState} from 'react';
import './ReportButton.css';
import Modal from 'react-modal';
import ReportForm from '../ReportForm/ReportForm';

class ReportButton extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			modal: false
		};
	}

	loadModal = () => {
		this.setState({modal: true})
	};

	closeModal = () => {
		this.setState({modal: false})
	};

	//Different states
	render() {
		return(
			<div>
				<button onClick={this.loadModal}>Report +</button>
				<Modal
    				isOpen={this.state.modal}
    				onRequestClose={this.closeModal}
					contentLabel="My Dialog">
        			<button onClick={this.closeModal}>x</button>
					<ReportForm></ReportForm>
				</Modal>
			</div>
		)
	}
}

export default ReportButton;
