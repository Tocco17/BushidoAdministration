import { createContext, ReactElement, useState } from "react";
import AuthInterface from "../interfaces/auth.interface";

type AuthContextType = {
    auth: AuthInterface | undefined
    setAuth: React.Dispatch<React.SetStateAction<AuthInterface | undefined>>
}

const AuthContext = createContext<AuthContextType>({
    auth: undefined,
    setAuth: () => {}
})

type AuthProviderProps = {
    children: ReactElement
}

export const AuthProvider = ({children} : AuthProviderProps) => {
    const [auth, setAuth] = useState<AuthInterface>()

    return (
        <AuthContext.Provider value={{auth, setAuth}}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext