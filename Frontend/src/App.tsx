import React from 'react';

import Navbar from './components/navbar/Navbar';
import Button from './components/button/Button';
import Footer from './components/footer/Footer';

import './styles/App.css';

const App: React.FC = (): React.JSX.Element => {
  return (
    <div className="App">
      <Navbar/>
      <Button/>
      <Footer/>
    </div>
  );
}

export default App;
