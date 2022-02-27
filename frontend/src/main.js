import { createApp } from 'vue'
import App from './App.vue'
import { VuesticPlugin } from 'vuestic-ui' // <-
import 'vuestic-ui/dist/vuestic-ui.css' // <-
import Vuex from 'vuex'

const app = createApp(App)
app.use(VuesticPlugin, {})
app.use(Vuex, {})
app.mount('#app')