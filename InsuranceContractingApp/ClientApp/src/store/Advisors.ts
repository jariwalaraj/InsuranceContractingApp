import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

export interface AdvisorsState {
    isLoading: boolean;
    startDateIndex?: number;
    Advisors: Advisor[];
}

export interface Advisor {
    advisorsId: number;
    firstName: number;
    lastName: number;
    address: string;
    phoneNumber: string;
    healthStatus: string;
}

interface RequestAdvisorsAction {
    type: 'REQUEST_ADVISORS';
    startDateIndex: number;
}

interface ReceiveAdvisorsAction {
    type: 'RECEIVE_ADVISORS';
    startDateIndex: number;
    Advisors: Advisor[];
}

type KnownAction = RequestAdvisorsAction | ReceiveAdvisorsAction;

export const actionCreators = {
    requestAdvisors: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        if (appState && appState.advisors && startDateIndex !== appState.advisors.startDateIndex) {
            fetch(`api/advisors/getalladvisors`)
                .then(response => response.json() as Promise<Advisor[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_ADVISORS', startDateIndex: startDateIndex, Advisors: data });
                });

            dispatch({ type: 'REQUEST_ADVISORS', startDateIndex: startDateIndex });
        }
    }
};

const unloadedState: AdvisorsState = { Advisors: [], isLoading: false };

export const reducer: Reducer<AdvisorsState> = (state: AdvisorsState | undefined, incomingAction: Action): AdvisorsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_ADVISORS':
            return {
                startDateIndex: action.startDateIndex,
                Advisors: state.Advisors,
                isLoading: true
            };
        case 'RECEIVE_ADVISORS':
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    Advisors: action.Advisors,
                    isLoading: false
                };
            }
            break;
    }

    return state;
};
