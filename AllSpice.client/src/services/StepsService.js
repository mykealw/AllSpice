import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class StepsService {

    async getSteps(id) {
        const res = await api.get('api/recipes/' + id + '/steps')
        logger.log(res.data, "steps got")
        AppState.steps = res.data
        AppState.steps.sort((a, b) => (a.position > b.position))
    }

    async addSteps(body) {
        const res = await api.post('api/steps', body)
        logger.log(res.data, "added step")
        AppState.steps.unshift(res.data)
        AppState.steps.sort((a, b) => (a.position < b.position))
    }

    async removeSteps(id) {
        const res = await api.delete('api/steps/' + id)
        logger.log(res.data, "removed step")
        AppState.steps = AppState.steps.filter(s => s.id != id)
    }

    async getIngredients(id) {
        const res = await api.get('api/recipes/' + id + '/ingredients')
        logger.log(res.data, "ingredients got")
        AppState.ingredients = res.data
    }

    async addIngredients(body) {
        const res = await api.post('api/ingredients', body)
        logger.log(res.data, "added ingredients")
        AppState.ingredients.unshift(res.data)
    }

    async removeIngredients(id) {
        const res = await api.delete('api/ingredients/' + id)
        logger.log(res.data, "deleted ingredients")
        AppState.ingredients = AppState.ingredients.filter(i => i.id != id)
    }
}

export const stepsService = new StepsService()