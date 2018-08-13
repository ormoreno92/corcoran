import React, { Component } from 'react';
import Header from '../header/Header';
import Footer from '../footer/Footer';
import Presidents from '../presidents/Presidents';

class App extends Component {
  render() {
    return (
      <div className="App">
        <Header />
        <Presidents />
        <Footer />
      </div>
    );
  }
}

export default App;
