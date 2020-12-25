import { WalletModel } from "./wallet.model";

export class AuthenticatedUserModel {
  token: string;
  userId: string;
  isAdmin: string;
  wallet: WalletModel;
}
