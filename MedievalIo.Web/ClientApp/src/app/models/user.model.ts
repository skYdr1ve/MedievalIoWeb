import { UserStatsModel } from "./user-stats.model";
import { StoreItemModel } from "./store-item.model";

export class UserModel {
  id: string;
  name: string;
  email: string;
  coins: number;
  gems: number;
  items: StoreItemModel[];
  stats: UserStatsModel;
}
