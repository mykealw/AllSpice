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
        AppState.myRecipes = await AppState.recipes.filter(r => r.creatorId == AppState.user.accountId)
        logger.log(AppState.myRecipes, "my recipes")
    }

    async getActiveRecipe(recipeId) {
        const res = await api.get('api/recipes/' + recipeId)
        logger.log(res.data, "active recipe")
        AppState.activeRecipe = res.data
    }

    async createRecipe(body) {

        const res = await api.post('api/recipes' + recipeData)
        logger.log(res.data, "recipe made")
        AppState.recipes = AppState.recipes.unshift(res.data)
        AppState.myRecipes = AppState.myRecipes.unshift(res.data)
    }

    async deleteRecipe(id) {
        const res = await api.delete('api/recipes/' + id)
        logger.log(res.data, "deleted")
        AppState.recipes = AppState.recipes.filter(r => r.id != id)
        AppState.myRecipes = AppState.myRecipes.filter(r => r.id != id)
    }

    async createFavorite(id) {

        let recipeData = {}
        recipeData.recipeId = id
        recipeData.accountId = AppState.user.id
        logger.log(recipeData, "going through")
        const res = await api.post('api/favorites', recipeData)
        logger.log(res.data, "favorited")
        AppState.favorites = AppState.favorites.unshift(res.data)
        AppState.myFavorites = AppState.myFavorites.unshift(res.data)
    }

    async deleteFavorite(id) {
        // debugger
        let deleteId = {}
        deleteId = AppState.myFavorites.filter(mf => mf.id == AppState.myFavorites.favoriteId)
        logger.log(deleteId, "delete id?")
        const res = await api.delete('api/favorites/' + id)
        logger.log(res.data, "deleted fav")
        AppState.favorites = AppState.favorites.filter(f => f.id != id)
        AppState.myFavorites = AppState.myFavorites.filter(f => f.id != id)
    }
}


export const recipesService = new RecipesService()