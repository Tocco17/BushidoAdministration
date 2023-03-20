import { createContext, ReactElement, useState } from "react";
import AuthInterface from "../interfaces/auth.interface";

type AuthContextType = {
    auth: AuthInterface | undefined
    setAuth: React.Dispatch<React.SetStateAction<AuthInterface | undefined>>
    persist: boolean
    setPersist: React.Dispatch<React.SetStateAction<boolean>>
}

const AuthContext = createContext<AuthContextType>({
    auth: undefined,
    setAuth: () => {},
    persist: false,
    setPersist: () => {}
})

type AuthProviderProps = {
    children: ReactElement
}

export const AuthProvider = ({children} : AuthProviderProps) => {
    const [auth, setAuth] = useState<AuthInterface>()
    const [persist, setPersist] = useState(false)

    return (
        <AuthContext.Provider value={{auth, setAuth, persist, setPersist}}>
            {children}
        </AuthContext.Provider>
    )
}

export default AuthContext