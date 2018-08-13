import React, { Component } from 'react';
import './Presidents.css';
import ReactDOM from 'react-dom';

var _ = require('lodash'),
  presidentsList = [],
  desc = false,
  url = 'https://corcoranomarapi.azurewebsites.net/api/presidents';

class Presidents extends Component {

  constructor() {
    super();
    getRequest(desc);
  }

  render() {
    return (
      <div className="container">
        <div id="Table" className="table-responsive">
        </div>
      </div>
    );
  }
}

function orderTable() {
  desc = !desc;
  getRequest(desc);
}


function getRows(row) {
  return (<tr>
    <th>{row.President}</th>
    <th className="center">{row.Birthday}</th>
    <th>{row.BirthPlace}</th>
    <th className="center">{row.DeathDay}</th>
    <th>{row.DeathPlace}</th>
  </tr>);
}

function getRequest(descending) {
  fetch(url + '?desc=' + descending)
    .then(response => {
      return response.json();
    }).then(data => {
      presidentsList = data;
      return (getTable(presidentsList))
    });
};

function getTable(list) {
  ReactDOM.render((
    <table className="table table-striped">
      <thead>
        <tr>
          <th onClick={orderTable} className="sort" >Name {desc ? '▲' : '▼' }</th>
          <th>Birthday</th>
          <th>Birth Place</th>
          <th>Death Day</th>
          <th>Death Place</th>
        </tr>
      </thead>
      <tbody>
        {_.map(presidentsList, getRows)}
      </tbody>
    </table>
  ), document.getElementById('Table'));
}

export default Presidents;
