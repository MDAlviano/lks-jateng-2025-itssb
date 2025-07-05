package com.alvin.d2_modul2.ui.profile

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.alvin.d2_modul2.R
import com.alvin.d2_modul2.model.User
import com.alvin.d2_modul2.session.SessionManager
import com.alvin.d2_modul2.util.ImageLoader

class ProfileScreen : Fragment() {

    private lateinit var iProfile: ImageView
    private lateinit var tvFullName: TextView
    private lateinit var tvEmail: TextView
    private lateinit var tvPhone: TextView

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_profile_screen, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val sessionManager = SessionManager(requireContext())
        val userData = sessionManager.fetchLoggedUser()

        initializeComponent(view = view)

        if (userData != null) {
            loadUserData(
                user = userData
            )
        }

    }

    private fun initializeComponent(view: View) {
        iProfile = view.findViewById(R.id.iProfile)
        tvFullName = view.findViewById(R.id.tvFullName)
        tvEmail = view.findViewById(R.id.tvEmail)
        tvPhone = view.findViewById(R.id.tvPhone)
    }

    private fun loadUserData(user: User) {
        tvFullName.text = user.fullName
        tvEmail.text = user.email
        tvPhone.text = user.phoneNumber

        ImageLoader.loadUserProfilePhoto(
            activity = requireActivity(),
            imageView = iProfile,
            imageUri = user.pictureUri
        )
    }

}