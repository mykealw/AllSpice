import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class RecipesService {

    async getAll() {
        const res = await api.get('api/recipes')
        logger.log(res.data, "all recipes")
        AppState.recipes = res.data
    }

    async getMyRecipes(accountId) {
        AppState.myRecipes = await AppState.recipes.filter(r => r.creatorId == accountId)
        logger.log(AppState.myRecipes, "my recipes")
    }

    async getActiveRecipe(recipeId) {
        const res = await api.get('api/recipes/' + recipeId)
        logger.log(res.data, "active recipe")
        AppState.activeRecipe = res.data
    }

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes' + recipeData)
        logger.log(res.data, "recipe made")
        AppState.recipes.unshift(res.data)
        AppState.myRecipes.unshift(res.data)
    }

    async deleteRecipe(id) {
        const res = await api.delete('api/recipes/' + id)
        logger.log(res.data, "deleted")
        AppState.recipes = AppState.recipes.filter(r => r.id != id)
        AppState.myRecipes = AppState.myRecipes.filter(r => r.id != id)
    }

    async createFavorite(body) {
        const res = await api.post('api/favorites', body)
        loggger.log(res.data, "favorited")
        AppState.favorites.unshift(res.data)
        AppState.myFavorites.unshift(res.data)
    }

    async deleteFavorite(id) {
        const res = await api.delete('api/favorites' + id)
        logger.log(res.data, "deleted fav")
        AppState.favorites = AppState.favorites.filter(f => f.id != id)
        AppState.myFavorites = AppState.myFavorites.filter(f => f.id != id)
    }
}


export const recipesService = new RecipesService()