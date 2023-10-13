import React from 'react';

import StartButton from './components/button/Button.tsx';
import Footer from './components/footer/Footer.tsx';

import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Reaction App</h1>
      </header>
      <StartButton/>
      <Footer/>
    </div>
  );
}

export default App;
