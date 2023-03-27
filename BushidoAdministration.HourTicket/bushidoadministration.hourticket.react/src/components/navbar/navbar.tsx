import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import { allRoutes, RouteInterface } from '../../utilities/routes/routes.utility';
import { useNavigate } from 'react-router';
import useAuth from '../../hooks/useAuth';
import { useEffect, useState } from 'react';
import getCssClass, { container } from '../../utilities/theme/theme-classes';
import { navbar } from './navbar.theme';

type NavbarComponentProps = {
    routes: RouteInterface[]
    settings: RouteInterface[]
}

function NavbarComponent({routes, settings} : NavbarComponentProps) {
    const auth = useAuth()
    const navigate = useNavigate()

    const handleMenuClick = (event: React.MouseEvent<HTMLElement>, route: RouteInterface) => {
        event.preventDefault()
        navigate(route.path)
    }

    return (
        <>
        <Box sx={getCssClass([container, navbar])}>

        </Box>
        <AppBar></AppBar>
        </>
    )
}
export default NavbarComponent;