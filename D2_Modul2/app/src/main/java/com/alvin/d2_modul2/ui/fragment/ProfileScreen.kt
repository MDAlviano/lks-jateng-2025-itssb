package com.alvin.d2_modul2.ui.fragment

import android.graphics.BitmapFactory
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import com.alvin.d2_modul2.R
import com.alvin.d2_modul2.model.User
import com.alvin.d2_modul2.session.SessionManager
import java.net.HttpURLConnection
import java.net.URL
import kotlin.concurrent.thread

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

        loadUserImage(
            imageUri = user.pictureUri
        )
    }

    private fun loadUserImage(imageUri: String) {
        thread {
            val url = URL("http://10.0.2.2:5000/images/$imageUri")
            val connection = url.openConnection() as HttpURLConnection
            connection.doInput = true
            connection.connect()

            val inputStream = connection.inputStream
            val bitmap = BitmapFactory.decodeStream(inputStream)

            if (connection.responseCode == HttpURLConnection.HTTP_OK) {
                requireActivity().runOnUiThread {
                    iProfile.setImageBitmap(bitmap)
                }
            }
        }
    }

}