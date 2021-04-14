import Vue from 'vue'
import Router from 'vue-router'
// import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import store from '../store/index'
import AddPlan from '../views/AddPlan.vue'
import AddRecipe from '../views/AddRecipe.vue'
import AddMeal from '../views/AddMeal.vue'
import ViewRecipes from '../views/ViewRecipes.vue'
import Home2 from '../views/Home2.vue'
import RecipeDetailView from '../views/RecipeDetailView.vue'
import ViewGroceries from '../views/ViewGroceries.vue'
import ViewMeal from '../views/ViewMeal.vue'
import RecipeEditView from '../views/RecipeEditView'
// Vue.ForceUpdate();

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  linkExactActiveClass: "active",
  linkActiveClass: "active",
  routes: [
    // {
    //   path: '/',
    //   name: 'home',
    //   component: Home,
    //   meta: {
    //     requiresAuth: true
    //   }
    // },
    {
      path: "/",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false
      }
    },
    {

      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false
      }
    },
    {
      path: "/AddPlan",
      name: "AddPlan",
      component: AddPlan,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/AddRecipe",
      name: "AddRecipe",
      component: AddRecipe,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/Meal",
      name: "ViewMeal",
      component: ViewMeal,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/AddMeal",
      name: "AddMeal",
      component: AddMeal,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/ViewRecipes",
      name: "ViewRecipes",
      component: ViewRecipes,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: "/Recipes/:id",
      name: 'RecipeDetailView',
      component: RecipeDetailView

    },
    {
      path: "/RecipesEdit/:idedit",
      name: 'RecipeEditView',
      component: RecipeEditView,
    },
    {
      path: '/home2',
      name: 'home2',
      component: Home2,
      meta: {
        requiresAuth: true
      }
    },
    {
      path: '/GroceryList',
      name: 'GroceryList',
      component: ViewGroceries,
      meta: {
        requiresAuth: true
      }
    }


  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
