import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

export interface CarriersState {
    isLoading: boolean;
    startDateIndex?: number;
    Carriers: Carrier[];
}

export interface Carrier {
    carrierId: number;
    businessName: string;
    businessAddress: string;
    phoneNumber: string;
}

interface RequestCarriersAction {
    type: 'REQUEST_CARRIERS';
    startDateIndex: number;
}

interface ReceiveCarriersAction {
    type: 'RECEIVE_CARRIERS';
    startDateIndex: number;
    Carriers: Carrier[];
}

type KnownAction = RequestCarriersAction | ReceiveCarriersAction;

export const actionCreators = {
    requestCarriers: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.carriers && startDateIndex !== appState.carriers.startDateIndex) {
            fetch(`api/carrier/getallcarriers`)
                .then(response => response.json() as Promise<Carrier[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_CARRIERS', startDateIndex: startDateIndex, Carriers: data });
                });

            dispatch({ type: 'REQUEST_CARRIERS', startDateIndex: startDateIndex });
        }
    }
};

const unloadedState: CarriersState = { Carriers: [], isLoading: false };

export const reducer: Reducer<CarriersState> = (state: CarriersState | undefined, incomingAction: Action): CarriersState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_CARRIERS':
            return {
                startDateIndex: action.startDateIndex,
                Carriers: state.Carriers,
                isLoading: true
            };
        case 'RECEIVE_CARRIERS':
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    Carriers: action.Carriers,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
