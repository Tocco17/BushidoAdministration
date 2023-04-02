import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import { RouteInterface } from '../../utilities/routes/routes.utility';
import { useNavigate } from 'react-router';
// import useAuth from '../../hooks/useAuth';
import getCssClass, { fontSize } from '../../utilities/theme/theme-classes';
import { navbar, white } from './navbar.theme';

// import logo from '../../assets/images/cropped-logo-bushido-1.png'
import { Button, Container } from '@mui/material';

type NavbarComponentProps = {
    routes: RouteInterface[]
    settings: RouteInterface[]
}

function NavbarComponent({routes, settings} : NavbarComponentProps) {
    //const timestamp = new Date().getTime(); // ottieni un timestamp univoco
    //const imagePath = `${logo}?t=${timestamp}`; // aggiungi il timestamp alla fine del percorso dell'immagine


    //const auth = useAuth()
    const navigate = useNavigate()

    const handleMenuClick = (event: React.MouseEvent<HTMLElement>, route: RouteInterface) => {
        event.preventDefault()
        navigate(route.path)
    }

    return (
        <>
        <AppBar position='static' sx={getCssClass([navbar])}>
            <Container maxWidth='xl'>
                <Box>
                    {
                        routes.map(r => (
                            <Button key={r.name} onClick={(e) => handleMenuClick(e, r)} sx={getCssClass([white, fontSize(20)])}>{r.name}</Button>
                        ))
                    }
                </Box>
            </Container>
        </AppBar>
        </>
    )
}
export default NavbarComponent;