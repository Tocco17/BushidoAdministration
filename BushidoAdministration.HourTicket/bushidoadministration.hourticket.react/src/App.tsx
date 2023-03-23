import React from 'react';
import logo from './logo.svg';
import './App.css';
import Routing from './components/routing';
import { ThemeProvider } from '@mui/system';
import CustomThemeProvider from './contextes/theme.context';

function App() {
  return (
    <>
    <CustomThemeProvider>
      <Routing />
    </CustomThemeProvider>
    </>
  );
}

export default App;
