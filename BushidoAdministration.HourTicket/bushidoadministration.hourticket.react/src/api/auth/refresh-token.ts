import AuthInterface from "../../interfaces/Auth"

//TODO - da sistemare il refresh token

const refreshToken = async () => {
    const data : AuthInterface = {
        roles: [],
        accessToken: '',
        user: {}
    }
    return {
        data
    }
}

export default refreshToken