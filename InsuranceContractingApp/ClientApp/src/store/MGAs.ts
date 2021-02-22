import { Action, Reducer } from 'redux';
import { AppThunkAction } from '.';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface MGAsState {
    isLoading: boolean;
    startDateIndex?: number;
    MGAs: MGA[];
}

export interface MGA {
    mgaId: number;
    contractorId: number;
    businessName: string;
    businessAddress: string;
    phoneNumber: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestMGAsAction {
    type: 'REQUEST_MGAS';
    startDateIndex: number;
}

interface ReceiveMGAsAction {
    type: 'RECEIVE_MGAS';
    startDateIndex: number;
    MGAs: MGA[];
}

interface UpdateMGAsAction {
    type: 'UPDATE_MGAS_REQUEST';
    startDateIndex: number;
    MGAs: MGA[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestMGAsAction | ReceiveMGAsAction | UpdateMGAsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestMGAs: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        const appState = getState();
        if (appState && appState.MGAs && startDateIndex !== appState.MGAs.startDateIndex) {
            fetch(`api/MGAs/GetAllMGAs`)
                .then(response => response.json() as Promise<MGA[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_MGAS', startDateIndex: startDateIndex, MGAs: data });
                });

            dispatch({ type: 'REQUEST_MGAS', startDateIndex: startDateIndex });
        }
    },

    updateMGA: (startDateIndex: number): AppThunkAction<KnownAction> => (dispatch, getState) => {
        const appState = getState();
        if (appState && appState.MGAs) {
            const requestOptions = {
                method: 'POST', 
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({})
            };
            fetch(`api/MGAs`, requestOptions)
                .then(response => response.json() as Promise<MGA>)
                
        }
    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: MGAsState = { MGAs: [], isLoading: false };

export const reducer: Reducer<MGAsState> = (state: MGAsState | undefined, incomingAction: Action): MGAsState => {
    if (state === undefined) {
        return unloadedState;
    }

    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_MGAS':
            return {
                startDateIndex: action.startDateIndex,
                MGAs: state.MGAs,
                isLoading: true
            };
        case 'RECEIVE_MGAS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            if (action.startDateIndex === state.startDateIndex) {
                return {
                    startDateIndex: action.startDateIndex,
                    MGAs: action.MGAs,
                    isLoading: false
                };
            }
            break;
        case 'UPDATE_MGAS_REQUEST':
            return {
                startDateIndex: action.startDateIndex,
                MGAs: action.MGAs,
                isLoading: false
            }
    }

    return state;
};
