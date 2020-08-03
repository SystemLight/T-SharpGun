import {ThunkDispatch} from "redux-thunk";

// reducer 存储纯函数类型定义
export type IReducerActionKeys = "DATE" | "OTHER";

export interface IReducerAction {
    type: IReducerActionKeys
}

export interface IReducerState {
    data: string
}

export type IDispatchReducer = ThunkDispatch<IReducerState, any, IReducerAction>;

export interface IReducers {
    reducer: IReducerState
}
