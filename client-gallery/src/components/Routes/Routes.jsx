import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Home  from '../Home/Home';
import { ROUTES } from '../../utils/routes';
import PageNotFound from '../PageNotFound/PageNotFound';
import Album from '../Album/Album';

const AppRoutes = () => (
    <Routes>
        <Route index element={<Home/>}/>
        <Route path={ROUTES.ALBUM} element={<Album/>}/>
        <Route path={ROUTES.ERROR} element={<PageNotFound />}/>
    
    </Routes>
)
export default AppRoutes;