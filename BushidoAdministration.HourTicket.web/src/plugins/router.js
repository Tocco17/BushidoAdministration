import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Calendar from '../views/Calendar.vue'
import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from "../stores/authStore"


const routes = [
    { path: '/Login', component: Login},
    { path: '/', component: Home, meta: { requiresAuth: true }},
    { path: '/Calendar', component: Calendar, meta: { requiresAuth: true, requiresAdmin: true }}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore()

    if(to.meta.requiresAdmin && !authStore.isAdmin){
        console.error(`ERRORE NEL CERCARE DI ACCEDERE A ${to.path}: percorso non accessibile`)
        next('/')
    }

    if (to.matched.some(record => record.meta.requiresAuth)) {
        if (authStore.isLogged) {
            next()
        } else {
            next('/Login')
        }
    } else {
        next()
    }
})

export default router


