import { ReactNode } from "react"
import DefaultLayout from "../../components/layouts/default-layout"
import EmptyLayout from "../../components/layouts/empty-layout"
import Role from "../../enums/role.enum"
import { allRoutes, RouteInterface } from "./routes.utility"

const {home, login, unauthorized, logout, notFound, details} = allRoutes

export interface RouteListInterface {
    routes: RouteInterface[]
}

export interface PrivateRouteListInterface extends RouteListInterface {
    allowedRoles: Role[]
}

export interface CompleteRouteListInterface {
    path: string
    element: ReactNode
    publicRoutes: RouteListInterface
    privateRoutes: PrivateRouteListInterface[]
}

export const publicRoutes : RouteListInterface = {
    routes: [home, login, unauthorized, logout, notFound]
}

export const privateNoRoleRoutes : PrivateRouteListInterface = {
    routes: [details],
    allowedRoles: []
}

const defaultLayoutRoutes : CompleteRouteListInterface = {
    path: '/',
    element: <DefaultLayout />,
    publicRoutes: {routes: [home]},
    privateRoutes: [
        {routes: [details], allowedRoles: []}
    ]
}

const emptyLayoutRoutes : CompleteRouteListInterface = {
    path: '/',
    element: <EmptyLayout />,
    publicRoutes: {routes: [login, unauthorized, logout, notFound]},
    privateRoutes: []
}

const everyCompleteRoutes : CompleteRouteListInterface[] = [
    defaultLayoutRoutes, emptyLayoutRoutes
]

export default everyCompleteRoutes

