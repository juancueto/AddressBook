import { ContactSearch } from '.'
import { NavLink } from "react-router-dom";

export const Header = () => {
  return (
    <>
        <div className="col-auto">
            <h2>
            Address Book
            </h2>
        </div>

        <div className="col-5 ">
            <ContactSearch />
        </div>
        <div className="col-2">
            <NavLink
            className="btn btn-outline-primary"
            to='/contacts/new'
            >
            New Contact
            </NavLink>
        </div>
    </>
  )
}
