import { ReactNode } from "react"
import Role from "../enums/role.enum"
import Unauthorized from "../pages/auth/unauthorized"
import Details from "../pages/details"
import Home from "../pages/home"
import Login from "../pages/login"

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

const details : RouteInterface = {
    name: 'Details',
    path: '/details',
    element: <Details />
}

export const allRoutes = {
    home,
    login,
    details,
    unauthorized
}

export const publicRoutes : RouteListInterface = {
    routes: [home, login]
}

export const privateNoRoleRoutes : PrivateRouteListInterface = {
    routes: [details],
    allowedRoles: []
}