import React from 'react';
import logo from './logo.svg';
import './App.css';
import Routing from './components/routing';
import { ThemeProvider } from '@emotion/react';
import theme from './themes';
import { useSelector } from 'react-redux';

function App() {
  const customization = useSelector((state) => state.customization)

  return (
    <>
    <ThemeProvider theme={theme(customization)}>

      <Routing />
    </ThemeProvider>
    </>
  );
}

export default App;
