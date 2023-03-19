import { createContext } from "react";
import AuthInterface from "../interfaces/auth.interface";

type AuthContextType = {
    auth: AuthInterface | undefined
    setAuth: React.Dispatch<React.SetStateAction<AuthInterface>>
}

const AuthContext = createContext<AuthContextType>({
    auth: undefined,
    setAuth: () => {}
})

export default AuthContext