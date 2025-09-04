import React from "react";
import { Route, Routes, Navigate } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import ArticleDetail from "./pages/ArticleDetail";
import EventDetail from "./pages/EventDetail";
import ArticleCreate from "./pages/ArticleCreate";
import EventCreate from "./pages/EventCreate";
import AdminLayout from "./pages/admin/AdminLayout";
import ArticleCategories from "./pages/admin/ArticleCategories";
import EventCategories from "./pages/admin/EventCategories";
import { RequireAdmin, RequireAuth } from "./auth/ProtectedRoute";

export default function App(){
  return (
    <>
      <Navbar/>
      <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/articles/new" element={<RequireAuth><ArticleCreate/></RequireAuth>} />
        <Route path="/articles/:id" element={<ArticleDetail/>} />
        <Route path="/events/new" element={<RequireAuth><EventCreate/></RequireAuth>} />
        <Route path="/events/:id" element={<EventDetail/>} />

        <Route path="/admin" element={<RequireAdmin><AdminLayout/></RequireAdmin>}>
          <Route index element={<Navigate to="article-categories" replace/>} />
          <Route path="article-categories" element={<ArticleCategories/>} />
          <Route path="event-categories" element={<EventCategories/>} />
        </Route>

        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </>
  );
}