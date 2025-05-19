import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '@/views/LoginView.vue'
import VistaPrincipal from '@/views/VistaPrincipal.vue'
import DeportesView from '@/views/DeportesView.vue'
import TecnologiaView from '@/views/TecnologiaView.vue'
import PoliticaView from '@/views/PoliticaView.vue'

const routes = [
  {
    path: '/',
    name: 'loginview',
    component: LoginView
  },
  {
    path: '/vistaprincipal',
    name: 'vistaprincipal',
    component: VistaPrincipal,
    props: true

  },
  {
    path: '/deportes',
    name: 'Deportes',
    component: DeportesView
  }, 
  {
    path: '/tecnologia',
    name: 'Tecnologia',
    component: TecnologiaView
  },  
  {
    path: '/politica',
    name: 'Politica',
    component: PoliticaView
  },   
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
