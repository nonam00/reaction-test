import React from 'react';

import Button from './components/button/Button';
import Footer from './components/footer/Footer';

import './styles/App.css';

const App: React.FC = (): React.JSX.Element =>
    <div className="App">
      <header className="App-header">
        <h1>Reaction App</h1>
      </header>
      <Button/>
      <Footer/>
    </div>;

export default App;
