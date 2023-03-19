import { ReactNode } from "react"
import Role from "../enums/role.enum"
import Unauthorized from "../pages/auth/unauthorized"
import Details from "../pages/details"
import Home from "../pages/home"
import Login from "../pages/auth/login"
import Logout from "../pages/auth/logout"

export interface RouteInterface {
    name: string
    path: string
    element: ReactNode
}

export interface RouteListInterface {
    routes: RouteInterface[]
}

export interface PrivateRouteListInterface extends RouteListInterface {
    allowedRoles: Role[]
}

const home : RouteInterface = {
    name: 'Home',
    path: '/',
    element: <Home/>
}

const login : RouteInterface = {
    name: 'Login',
    path: '/login',
    element: <Login/>
}

const unauthorized : RouteInterface = {
    name: 'Unauthorized',
    path: '/unauthorized',
    element: <Unauthorized />
}

const logout : RouteInterface = {
    name: 'Logout',
    path: '/logout',
    element: <Logout/>
}

const details : RouteInterface = {
    name: 'Details',
    path: '/details',
    element: <Details />
}

export const allPath = {
    home: home.path,
    login: login.path,
    details: details.path,
    unauthorized: unauthorized.path,
    logout: logout.path,
}

export const publicRoutes : RouteListInterface = {
    routes: [home, login, unauthorized, logout]
}

export const privateNoRoleRoutes : PrivateRouteListInterface = {
    routes: [details],
    allowedRoles: []
}