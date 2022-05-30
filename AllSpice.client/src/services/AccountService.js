import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getMyFavs() {
    const res = await api.get('/account/Favorites')
    logger.log(res.data, "favorites")
    AppState.favorites = res.data

    AppState.myFavorites = AppState.favorites.filter(f => f.accountId == AppState.user.accountId)
    logger.log(AppState.myFavorites, "my favs")
  }
}

export const accountService = new AccountService()
