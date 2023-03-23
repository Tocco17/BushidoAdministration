import { useState } from 'react'
import { Button, TextField } from '@mui/material'
import loginApi from '../../api/auth.api.ts/login.api';
import { Link, useLocation, useNavigate } from 'react-router-dom';
import useAuth from '../../hooks/useAuth';
import { allPath } from '../../utilities/routes/routes.utility';

const Login = () => {
    const navigate = useNavigate()
    const location = useLocation()
    const from = location.state?.from?.pathname || '/'

    const {auth, setAuth} = useAuth()
    
    const [username, setUsername] = useState('')
    const [password, setPassword] = useState('')

    const handleUsernameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setUsername(event.target.value)
    }

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value)
    }

    const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault()

        const user = loginApi(username, password)

        if(!user) return console.error('Not logged')
        
        setAuth({...auth, user: user})
        
        navigate(from, {replace: true})
    }

    return (
        <>
        <form onSubmit={handleSubmit}>
            <TextField label="Username" value={username} onChange={handleUsernameChange} />
            <TextField label="Password" type="password" value={password} onChange={handlePasswordChange} />

            <Button type="submit" variant="contained" color="primary">
                Login
            </Button>
        </form>
        </>
    );
};


export default Login