import { ReactNode } from "react"
import Role from "../enums/role.enum"
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

export const publicRoutes : RouteListInterface = {
    routes: [login]
}

export const privateRoutes : PrivateRouteListInterface = {
    routes: [home],
    allowedRoles: [Role.admin, Role.coach]
}