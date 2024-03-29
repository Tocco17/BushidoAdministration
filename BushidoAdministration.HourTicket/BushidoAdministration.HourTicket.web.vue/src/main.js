import { createApp } from 'vue'
// import './style.css'
// import './input.css'
import App from './App.vue'
import router from './plugins/router'
import pinia from './plugins/pinia'

const app = createApp(App)

app.use(router)
app.use(pinia)

app.mount('#app')