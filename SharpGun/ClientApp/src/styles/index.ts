import styled from "styled-components";

export const SRect = styled.div`
    width: 100px;
    height: 100px;
    line-height: 100px;
    white-space: nowrap;
    color: white;
    overflow: hidden;
    font-size: 18px;
    font-weight: bold;
    text-align: center;
    user-select: none;
    cursor: pointer;
    background-color: #50504d;
    box-shadow: #333333 0 0 5px 1px;
    text-shadow: #333333 5px 5px 5px;

    &:hover{
        color: #2f6036;
        background-color: #4e78c1;
    }
`;
