import { createContext, ReactElement, useState } from "react";
import AuthInterface from "../interfaces/Auth";
import { readStorage } from "../utilities/storage.utility";

export type AuthContextType = {
    auth: AuthInterface,
    setAuth: React.Dispatch<React.SetStateAction<AuthInterface>>,
    persist: Boolean,
    setPersist: React.Dispatch<React.SetStateAction<Boolean>>
}

const emptyAuth : AuthInterface = {
    roles: [],
    accessToken: '',
    user: {}
}

const AuthContext = createContext<AuthContextType>({
    auth: emptyAuth,
    setAuth: () => emptyAuth,
    persist: false,
    setPersist: () => {}
})

type AuthProviderProps = {
    children: ReactElement
}

export const AuthProvider = ({children} : AuthProviderProps) => {
    const [auth, setAuth] = useState<AuthInterface>(emptyAuth)
    const [persist, setPersist] = useState(JSON.parse(readStorage('persist')) as Boolean || false)

    return (
        <>
        <AuthContext.Provider value={{auth, setAuth, persist, setPersist}}>
            {children}
        </AuthContext.Provider>
        </>
    )
}

export default AuthContext