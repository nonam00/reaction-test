import React from 'react';

import Button from './components/button/Button';
import ResultsComponent from './components/results/ResultsComponent';
import Footer from './components/footer/Footer';

import './styles/App.css';

const App: React.FC = (): React.JSX.Element => {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Reaction App</h1>
      </header>
      <Button/>
      <ResultsComponent/>
      <Footer/>
    </div>
  );
}

export default App;
