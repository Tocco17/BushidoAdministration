// ts-check
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import { createRouter, createWebHistory } from 'vue-router'
import { useAuthStore } from "../stores/authStore"


const routes = [
    { path: '/', component: Home, meta: { requiresAuth: true }},
    { path: '/Login', component: Login}
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

router.beforeEach((to, from, next) => {
    const authStore = useAuthStore()

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


