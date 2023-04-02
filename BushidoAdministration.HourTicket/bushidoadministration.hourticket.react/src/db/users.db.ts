import Role from "../enums/role.enum";
import User from "../interfaces/models/User";

const UsersDb : User[] = [
    {
        id: 1,
        email: 'president@admin.com',
        password: 'admin',
        roles: [
            Role.admin
        ]
    }
]

export default UsersDb