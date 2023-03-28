import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import { RouteInterface } from '../../utilities/routes/routes.utility';
import { useNavigate } from 'react-router';
import useAuth from '../../hooks/useAuth';
import getCssClass, { container } from '../../utilities/theme/theme-classes';
import { navbar } from './navbar.theme';

import logo from '../../assets/images/cropped-logo-bushido-1.png'

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
            {/* <AppBar sx={{backgroundImage: 'url(../../assets/images/cropped-logo-bushido-1.png)', backgroundSize: 'cover'}}> */}
            <AppBar>
                <Box component="img" src={`url(${logo})`}></Box>
            </AppBar>
        </Box>
        </>
    )
}
export default NavbarComponent;