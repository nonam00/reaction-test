import React, { FC, ReactElement } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import AuthProvider from './auth/auth-provider';
import SignoutOidc from './auth/SignoutOidc';
import SigninOidc from './auth/SigninOidc';
import userManager, {  loadUser } from './auth/user-service';

import GameComponent from './components/game/GameComponent';

import './styles/App.css';
import UnauthorizedPage from './components/game/UnauthorizedPage';

const App: FC = (): ReactElement => {
  loadUser();
  return (
    <div className="App">
      <AuthProvider userManager={userManager}>
        <Router>
          <Routes>
            <Route
              path='/'
              element={<GameComponent />}
            />
            <Route
              path = '/signout-oidc'
              element={<SignoutOidc />}
            />
            <Route
              path='/signin-oidc'
              element={<SigninOidc />}
            />
            <Route
              path='/unauthorized'
              element={<UnauthorizedPage />}
            />
          </Routes>
        </Router>
      </AuthProvider>
    </div>
  );
}

export default App;
