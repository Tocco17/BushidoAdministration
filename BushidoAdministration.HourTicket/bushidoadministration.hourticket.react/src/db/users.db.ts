import Roles from "../enums/roles.enum";
import User from "../interfaces/User";

const UsersDb : User[] = [
    {
        id: 1,
        email: 'president@admin.com',
        password: 'admin',
        roles: [
            Roles.admin
        ]
    }
]

export default UsersDb