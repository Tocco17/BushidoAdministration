import { ReactNode } from "react"

import Unauthorized from "../pages/auth/unauthorized"
import Details from "../pages/details"
import Home from "../pages/home"
import Login from "../pages/auth/login"
import Logout from "../pages/auth/logout"
import NoPage from "../pages/no-page"

export interface RouteInterface {
    name: string
    path: string
    element: ReactNode
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

const notFound : RouteInterface = {
    name: 'NotFound',
    path: '*',
    element: <NoPage />
}

export const allRoutes = {
    home,
    login,
    details,
    unauthorized,
    logout,
    notFound,
}

export const allPath = {
    home: home.path,
    login: login.path,
    details: details.path,
    unauthorized: unauthorized.path,
    logout: logout.path,
    notFound: notFound.path,
}