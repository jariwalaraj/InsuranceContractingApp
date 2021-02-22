import * as MGAs from './MGAs';
import * as Advisors from './Advisors';
import * as Carriers from './Carriers';

// The top-level state object
export interface ApplicationState {
    advisors: Advisors.AdvisorsState | undefined;
    carriers: Carriers.CarriersState | undefined;
    MGAs: MGAs.MGAsState | undefined;
}

export const reducers = {
    MGAs: MGAs.reducer,
    advisors: Advisors.reducer,
    carriers: Carriers.reducer
};

export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
