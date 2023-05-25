import React from 'react';
import logo from './logo.svg';
import './App.css';
import Routing from './components/routing';
import { ThemeProvider } from '@mui/system';
import CustomThemeProvider from './contextes/theme.context';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs'

function App() {
  return (
    <>
    <CustomThemeProvider>
      <LocalizationProvider dateAdapter={AdapterDayjs}>
        <Routing />
      </LocalizationProvider>
    </CustomThemeProvider>
    </>
  );
}

export default App;
