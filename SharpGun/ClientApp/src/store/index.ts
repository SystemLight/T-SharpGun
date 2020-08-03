import {createStore, combineReducers, applyMiddleware} from "redux";
import thunk from "redux-thunk";
import {createSelector} from "reselect";

import reducer from "@/store/reducer/reducer";
import {IReducers, IReducerState} from "@/types/store";

/*
    创建一个redux数据存储库
 */
export default createStore(combineReducers<IReducers>({
    reducer: reducer
}), applyMiddleware(thunk));

/*
    捕获reducer纯函数的data内容
 */
export const reducerDataSelector = createSelector<IReducers, IReducerState, string>(
    (reducers) => {
        return reducers.reducer;
    },
    (state) => {
        return state.data;
    }
);
