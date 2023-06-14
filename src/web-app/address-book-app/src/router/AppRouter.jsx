import { Route, Routes } from "react-router-dom"
import { ContactsRoutes } from "../contacts/routes/ContactsRoutes"
import { Header } from "../contacts/components"

export const AppRouter = () => {
  return (
    <>
      <div className='container mt-4 mb-4'>
        <div className="row">
            <Header />            
          </div>        

          <hr />

          <Routes>
              <Route path="/*" element={<ContactsRoutes />}></Route>
          </Routes>
      </div>
    </>
  )
}
