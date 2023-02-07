import { defineStore } from 'pinia'
import { localStoragePlugin } from '../plugins/localStoragePlugin'
import router from '../plugins/router'

export const useAuthStore = defineStore('auth', {
    state: () => {
        return {
            _isLogged: false
        }
    },
    actions: {
        login(username, password, inLocalStorage) {
            if (inLocalStorage)
                localStoragePlugin.write('auth', {username, password})

            return new Promise((resolve, reject) => {
                this._isLogged = true;
                resolve(true);
            });
        },
        logout() {
            this._isLogged = false;
            localStorage.clear();
            router.push('/Login');
        },
        
        getRole(username){
            if(!username) username = localStoragePlugin.read('auth.username') 
            
            //TODO: add API for role management

            return username === 'Tocco' ? 'admin' : 'coach'
        },
    },
    getters: {
        isLogged() {
            return this._isLogged || !!localStoragePlugin.read('auth')
        },
        isAdmin() {
            return this.isLogged && this.getRole() === 'admin'
        }
    }
})